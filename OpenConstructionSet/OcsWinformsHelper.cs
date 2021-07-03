using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using forgotten_construction_set;
using static forgotten_construction_set.navigation;

namespace OpenConstructionSet
{
    /// <summary>
    /// The <c>GameData</c> object is tied to UI so we need to do some stupid stuff to get it working.
    /// </summary>
    public static class OcsWinformsHelper
    {
        //  Property used to access Application.OpenForms in a mutable way so we can add our fake windows
        private static readonly PropertyInfo innerListProperty = typeof(ReadOnlyCollectionBase).GetProperty("InnerList", BindingFlags.NonPublic | BindingFlags.Instance);

        // This is the singleton field for the Errors class. It neees to be set or any errors will crash the app
        private static readonly FieldInfo errorsInstanceField = typeof(Errors).GetField("instance", BindingFlags.NonPublic | BindingFlags.Static);

        // This field contains the list that holds errors. It neees to be set or any errors will crash the app
        private static readonly FieldInfo errorsErrorsField = typeof(Errors).GetField("errors", BindingFlags.NonPublic | BindingFlags.Instance);

        /// <summary>
        /// If <c>true</c> the infrastructure is in place to use <c>GameData</c> objects.
        /// </summary>
        public static bool Initialised { get; private set; }

        /// <summary>
        /// Empty instance of the base form.
        /// </summary>
        static baseForm baseForm;

        /// <summary>
        /// Empty instance of the navigation form
        /// </summary>
        static navigation nav;

        /// <summary>
        /// Semi empty instance of the errors form
        /// </summary>
        static Errors errors;

        /// <summary>
        /// Get or set the FileMode. 
        /// Due to the GameData class being tied to the UI they all share this value.
        /// </summary>
        public static ModFileMode FileMode
        {
            get
            {
                Init();

                return nav.FileMode;
            }

            set
            {
                Init();

                nav.FileMode = value;
            }
        }

        /// <summary>
        /// We need to do some magic 
        /// </summary>
        /// <param name="mode"></param>
        public static void Init()
        {
            if (Initialised)
            {
                return;
            }

            // Create the WinForms objects without calling the constructor
            baseForm = (baseForm)FormatterServices.GetUninitializedObject(typeof(baseForm));
            nav = (navigation)FormatterServices.GetUninitializedObject(typeof(navigation));

            baseForm.nav = nav;
            nav.FileMode = ModFileMode.USER;

            // Add the baseForm to Application.OpenForms
            var innerList = (ArrayList)innerListProperty.GetValue(Application.OpenForms);
            innerList.Add(baseForm);

            // Create Errors instance and set the singlton field.
            errors = (Errors)FormatterServices.GetUninitializedObject(typeof(Errors));
            errorsInstanceField.SetValue(errors, errors);

            // Errors.Item is private so use reflection to create a new List<Errors.Item> and set the field
            var type = typeof(Errors).GetNestedType("Item", BindingFlags.NonPublic);
            var listType = typeof(List<>).MakeGenericType(type);
            var errorsList = Activator.CreateInstance(listType);
            errorsErrorsField.SetValue(errors, errorsList);

            // Verify
            if (!Verify())
            {
                throw new InvalidOperationException("Failed to initialize WinForms infrastructure");
            }

            Initialised = true;

            // Verify that nav is available and the file mode is correctly set
            bool Verify() => Application.OpenForms.OfType<baseForm>().FirstOrDefault()?.nav?.FileMode == mode
                        && errorsInstanceField.GetValue(errors) != null
                        && errorsErrorsField.GetValue(errors) != null;
        }
    }
}
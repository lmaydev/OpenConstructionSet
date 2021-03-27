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
    public static class WinFormsInfrastructure
    {
        //  Property used to access Application.OpenForms in a mutable way so we can add our fake windows
        private static readonly PropertyInfo innerListProperty = typeof(ReadOnlyCollectionBase).GetProperty("InnerList", BindingFlags.NonPublic | BindingFlags.Instance);

        // This is the singleton field for the Errors class. It neees to be set or any errors will crash the app
        private static readonly FieldInfo errorsInstanceField = typeof(Errors).GetField("instance", BindingFlags.NonPublic | BindingFlags.Static);

        // This field contains the list that holds errors. It neees to be set or any errors will crash the app
        private static readonly FieldInfo errorsErrorsField = typeof(Errors).GetField("errors", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool Initialised { get; private set; }

        public static baseForm BaseForm { get; private set; }

        public static navigation Nav { get; private set; }

        public static Errors Errors { get; private set; }

        public static ModFileMode FileMode
        {
            get
            {
                if (!Initialised)
                    Init();

                return Nav.FileMode;
            }

            set
            {
                if (!Initialised)
                    Init();

                Nav.FileMode = value;
            }
        }

        public static void Init(ModFileMode mode = ModFileMode.USER)
        {
            if (Initialised)
            {
                return;
            }

            // Create the WinForms objects without calling the constructor
            BaseForm = (baseForm)FormatterServices.GetUninitializedObject(typeof(baseForm));
            Nav = (navigation)FormatterServices.GetUninitializedObject(typeof(navigation));

            BaseForm.nav = Nav;
            Nav.FileMode = mode;

            // Add the baseForm to Application.OpenForms
            var innerList = (ArrayList)innerListProperty.GetValue(Application.OpenForms);
            innerList.Add(BaseForm);

            // Create Errors instance and set the singlton field.
            Errors = (Errors)FormatterServices.GetUninitializedObject(typeof(Errors));
            errorsInstanceField.SetValue(Errors, Errors);

            // Errors.Item is private so use reflection to create a new List<Errors.Item> and set the field
            var type = typeof(Errors).GetNestedType("Item", BindingFlags.NonPublic);
            var listType = typeof(List<>).MakeGenericType(type);
            var errorsList = Activator.CreateInstance(listType);
            errorsErrorsField.SetValue(Errors, errorsList);

            // Verify
            if (!Verify())
            {
                throw new InvalidOperationException("Failed to initialize WinForms infrastructure");
            }

            Initialised = true;

            // Verify that nav is available and the file mode is correctly set
            bool Verify() => Application.OpenForms.OfType<baseForm>().FirstOrDefault()?.nav?.FileMode == mode
                        && errorsInstanceField.GetValue(Errors) != null
                        && errorsErrorsField.GetValue(Errors) != null;
        }
    }
}
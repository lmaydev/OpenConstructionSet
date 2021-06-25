# Open Construction Set
A wrapper SDK for the Forgotten Construction Set.
Allows creating, loading, querying, editing and saving of mods and game data.

## Current State
It is currently possible to:
 - Load mod files and their dependencies
 - Load a mod as active
 - Query data
 - Edit data
 - Save mods

The [example in the repo](OpenConstructionSet.Example/Program.cs) demonstrates a basic content patcher.

## Prerequisites
 - Kenshi with FCS
 - .Net 4.8

## Setup
You must set the KenshiFolder property in the projects.

Any applications must be built for x86.

namespace FNAECSTemplate.Components
{
    //components are just structs, they don't need to inherit from anything
    public struct ExampleComponent
    {
        public float ExampleProperty { get; }

        //in general, it's good practice to use these read-only autoproperties in your components
        //this prevents you from modifying a component without resetting it
        //because structs are value types and not reference types, 
        //recreating the struct with every update doesn't incur a performance penalty
        public ExampleComponent(float exampleProperty)
        {
            ExampleProperty = exampleProperty;
        }
    }
}
namespace FNAECSTemplate.Components
{
    /*
    this is a component. in ECS, a component is a store of data. never put logic on a component. 
    components do not need to hold any data: you can also create an empty component to use as a flag to indicate
    that it is of a certain type or has a certain capability. 
    */
    public struct ExampleComponent
    {
        public float ExampleProperty { get; }

        /*
        in general, it's good practice to use these read-only autoproperties in your components
        this prevents you from modifying a component without resetting it
        because structs are value types and not reference types, 
        recreating the struct with every update doesn't incur a performance penalty.
        */
        public ExampleComponent(float exampleProperty)
        {
            ExampleProperty = exampleProperty;
        }
    }
}
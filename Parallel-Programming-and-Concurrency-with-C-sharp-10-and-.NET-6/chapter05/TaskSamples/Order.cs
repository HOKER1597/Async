namespace TaskSamples
{
    // This class represents an order with an Id and a Name.
    // The Id property is an integer that uniquely identifies the order.
    // The Name property is an optional string that provides a name for the order.
    public class Order
    {
        // Gets or sets the unique identifier of the order.
        public int Id { get; set; }

        // Gets or sets the name of the order.
        // This property is optional and can be null.
        public string? Name { get; set; }
    }
}
namespace BackEnd.API.Models;

/// <summary>
/// 
/// </summary>
public sealed class Product
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; set; } = default!;
    
    /// <summary>
    /// 
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Stock { get; set; }
}

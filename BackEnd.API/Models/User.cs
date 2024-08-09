namespace BackEnd.API.Models;

/// <summary>
/// 
/// </summary>
public sealed class User
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
    public string Bio { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string UserName { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; } = default!;
}

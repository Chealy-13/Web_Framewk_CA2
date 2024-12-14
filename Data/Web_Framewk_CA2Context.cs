using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Framewk_CA2.Data;

namespace Web_Framewk_CA2.Data
{
    public class Web_Framewk_CA2Context(DbContextOptions<Web_Framewk_CA2Context> options) : IdentityDbContext<Web_Framewk_CA2User>(options)
    {
    }
}

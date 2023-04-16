using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.Common.Helpers;
public static class FileHelpers
{
    public static bool IsFileUploaded(this IFormFile file)
    {
        return file is { Length: > 0 };
    }
}

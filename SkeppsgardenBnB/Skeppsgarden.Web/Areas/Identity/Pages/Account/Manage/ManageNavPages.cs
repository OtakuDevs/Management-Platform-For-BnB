namespace Skeppsgarden.Web.Areas.Identity.Pages.Account.Manage;

#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

public static class ManageNavPages
{
    public static string Index => "Index";
    
    public static string Email => "Email";
    
    public static string ChangePassword => "ChangePassword";
    
    public static string TwoFactorAuthentication => "TwoFactorAuthentication";
    
    public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
    
    public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);
    
    public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
    
    public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) =>
        PageNavClass(viewContext, TwoFactorAuthentication);
    
    public static string PageNavClass(ViewContext viewContext, string page)
    {
        var activePage = viewContext.ViewData["ActivePage"] as string
                         ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
        return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
    }
}
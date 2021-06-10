using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ZaksCms.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.MapPageRoute("Login", "Loginpage", "~/Login.aspx");
           
            RouteTable.Routes.MapPageRoute("Home page", "Home", "~/Template/Main/Home.aspx");

            RouteTable.Routes.MapPageRoute("List Albums", "ListAlbum", "~/Template/Albums/ListAlbum.aspx");
            RouteTable.Routes.MapPageRoute("Add Albums", "AddAlbum", "~/Template/Albums/AddAlbum.aspx");
            RouteTable.Routes.MapPageRoute("Edit Albums", "EditAlbum/{ID}", "~/Template/Albums/EditAlbum.aspx");

            RouteTable.Routes.MapPageRoute("List Authors", "ListAuthor", "~/Template/Authors/ListAuthor.aspx");
            RouteTable.Routes.MapPageRoute("Add Author", "AddAuthor", "~/Template/Authors/AddAuthor.aspx");
            RouteTable.Routes.MapPageRoute("Edit Author", "EditAuthor/{ID}", "~/Template/Authors/EditAuthor.aspx");

            RouteTable.Routes.MapPageRoute("List Category", "ListCategory", "~/Template/Category/ListCategory.aspx");
            RouteTable.Routes.MapPageRoute("Insert Category", "AddCategory", "~/Template/Category/InsertCategory.aspx");
            RouteTable.Routes.MapPageRoute("Update Category", "EditCategory/{ID}", "~/Template/Category/UpdateCategory.aspx");

            RouteTable.Routes.MapPageRoute("List Color", "ListColors", "~/Template/Color/ListColors.aspx");
            RouteTable.Routes.MapPageRoute("Insert Color", "AddColor", "~/Template/Color/InsertColor.aspx");
            RouteTable.Routes.MapPageRoute("Update Color", "EditColor/{ID}", "~/Template/Color/UpdateColor.aspx");

            RouteTable.Routes.MapPageRoute("List Content", "ListContent", "~/Template/Content/ListContent.aspx");
            RouteTable.Routes.MapPageRoute("Add Content", "AddContent", "~/Template/Content/AddContent.aspx");
            RouteTable.Routes.MapPageRoute("Edit Content", "EditContent/{ID}", "~/Template/Content/EditContent.aspx");

            RouteTable.Routes.MapPageRoute("List Direction", "ListDirection", "~/Template/Directions/ListDirection.aspx");
            RouteTable.Routes.MapPageRoute("Add Direction", "AddDirection", "~/Template/Directions/AddDirection.aspx");
            RouteTable.Routes.MapPageRoute("Edit Direction", "EditDirection/{ID}", "~/Template/Directions/EditDirection.aspx");

            RouteTable.Routes.MapPageRoute("List Language", "ListLanguage", "~/Template/Language/ListLanguage.aspx");
            RouteTable.Routes.MapPageRoute("Add Language", "AddLanguage", "~/Template/Language/AddLanguage.aspx");
            RouteTable.Routes.MapPageRoute("Edit Language","EditLanguage/{ID}", "~/Template/Language/EditLanguage.aspx");

            RouteTable.Routes.MapPageRoute("List Menu", "ListMenu", "~/Template/Menu/ListMenu.aspx");
            RouteTable.Routes.MapPageRoute("Add Menu", "AddMenu", "~/Template/Menu/AddMenu.aspx");
            RouteTable.Routes.MapPageRoute("Edit Menu", "EditMenu/{ID}", "~/Template/Menu/EditMenu.aspx");

            RouteTable.Routes.MapPageRoute("List News", "ListNews", "~/Template/News/ListNews.aspx");
            RouteTable.Routes.MapPageRoute("Insert News","AddNews", "~/Template/News/InsertNews.aspx");
            RouteTable.Routes.MapPageRoute("Update News", "EditNews/{ID}", "~/Template/News/UpdateNews.aspx");
            //CHeck if the file path is right
            RouteTable.Routes.MapPageRoute("List Products", "ListProducts", "~/Template/Products/ListProducts.aspx");
            RouteTable.Routes.MapPageRoute("Insert Products", "AddProducts", "~/Template/Products/InsertProduct.aspx");
            RouteTable.Routes.MapPageRoute("Edit Products", "EditProducts/{ID}", "~/Template/Products/EditProduct.aspx");

            RouteTable.Routes.MapPageRoute("List ProductType", "ListProductTypes", "~/Template/ProductType/ListProductTypes.aspx");
            RouteTable.Routes.MapPageRoute("Add ProductType", "AddProductType", "~/Template/ProductType/AddProductType.aspx");
            RouteTable.Routes.MapPageRoute("Edit ProductType", "EditProductType/{ID}", "~/Template/ProductType/EditProductType.aspx");

            RouteTable.Routes.MapPageRoute("List Roles", "ListRoles", "~/Template/Roles/ListRoles.aspx");

            RouteTable.Routes.MapPageRoute("Settings", "Settings", "~/Template/Settings/Settings.aspx");

            RouteTable.Routes.MapPageRoute("List Source", "ListSources", "~/Template/Source/ListSources.aspx");
            RouteTable.Routes.MapPageRoute("Add Source", "AddSource", "~/Template/Source/AddSource.aspx");
            RouteTable.Routes.MapPageRoute("Edit Source", "EditSource/{ID}", "~/Template/Source/EditSource.aspx");

            RouteTable.Routes.MapPageRoute("List Zones", "ListZones", "~/Template/Zones/ListZones.aspx");
            RouteTable.Routes.MapPageRoute("Add Zones", "AddZone", "~/Template/Zones/AddZone.aspx");
            RouteTable.Routes.MapPageRoute("Edit Zones", "EditZone/{ID}", "~/Template/Zones/EditZones.aspx");

            RouteTable.Routes.MapPageRoute("Subscribe", "Subscribe", "~/Template/Subscribe/Subscribe.aspx");

            //RouteTable.Routes.MapPageRoute("FileUpload", "admin/FileUpload", "~/Admin/UserControl/Template/Upload/FileUpload.aspx");

            RouteTable.Routes.MapPageRoute("List Users", "ListUsers", "~/Template/User/ListUsers.aspx");
            RouteTable.Routes.MapPageRoute("Recover Password", "RecoverPassword", "~/Template/Users/RecoverPassword.aspx");
            RouteTable.Routes.MapPageRoute("Register", "Register", "~/Template/User/Register.aspx");
            RouteTable.Routes.MapPageRoute("ViewMore", "ViewMore", "~/Template/User/ViewMore.aspx");

            RouteTable.Routes.MapPageRoute("List Widget", "ListWidget", "~/Template/Widget/ListWidget.aspx");
            RouteTable.Routes.MapPageRoute("Add Widget", "AddWidget", "~/Template/Widget/AddWidget.aspx");
            RouteTable.Routes.MapPageRoute("Edit Widget", "EditWidget/{ID}", "~/Template/Widget/EditWidget.aspx");

            //RouteTable.Routes.MapPageRoute("List Authors", "admin/ListAuthor", "~/Admin/UserControl/Template/Authors/ListAuthor.aspx");
            //RouteTable.Routes.MapPageRoute("Add Author", "admin/AddAuthor", "~/Admin/UserControl/Template/Authors/AddAuthor.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Author", "admin/EditAuthor/{ID}", "~/Admin/UserControl/Template/Authors/EditAuthor.aspx");

            //RouteTable.Routes.MapPageRoute("List Category", "admin/ListCategory", "~/Admin/UserControl/Template/Category/ListCategory.aspx");
            //RouteTable.Routes.MapPageRoute("Insert Category", "admin/AddCategory", "~/Admin/UserControl/Template/Category/InsertCategory.aspx");
            //RouteTable.Routes.MapPageRoute("Update Category", "admin/EditCategory/{ID}", "~/Admin/UserControl/Template/Category/UpdateCategory.aspx");

            //RouteTable.Routes.MapPageRoute("List Color", "admin/ListColors", "~/Admin/UserControl/Template/Color/ListColors.aspx");
            //RouteTable.Routes.MapPageRoute("Insert Color", "admin/AddColor", "~/Admin/UserControl/Template/Color/InsertColor.aspx");
            //RouteTable.Routes.MapPageRoute("Update Color", "admin/EditColor/{ID}", "~/Admin/UserControl/Template/Color/UpdateColor.aspx");

            //RouteTable.Routes.MapPageRoute("List Content", "admin/ListContent", "~/Admin/UserControl/Template/Content/ListContent.aspx");
            //RouteTable.Routes.MapPageRoute("Add Content", "admin/AddContent", "~/Admin/UserControl/Template/Content/AddContent.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Content", "admin/EditContent/{ID}", "~/Admin/UserControl/Template/Content/EditContent.aspx");

            //RouteTable.Routes.MapPageRoute("List Direction", "admin/ListDirection", "~/Admin/UserControl/Template/Directions/ListDirection.aspx");
            //RouteTable.Routes.MapPageRoute("Add Direction", "admin/AddDirection", "~/Admin/UserControl/Template/Directions/AddDirection.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Direction", "admin/EditDirection/{ID}", "~/Admin/UserControl/Template/Directions/EditDirection.aspx");

            //RouteTable.Routes.MapPageRoute("List Language", "admin/ListLanguage", "~/Admin/UserControl/Template/Language/ListLanguage.aspx");
            //RouteTable.Routes.MapPageRoute("Add Language", "admin/AddLanguage", "~/Admin/UserControl/Template/Language/AddLanguage.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Language", "admin/EditLanguage/{ID}", "~/Admin/UserControl/Template/Language/EditLanguage.aspx");

            //RouteTable.Routes.MapPageRoute("List Menu", "admin/ListMenu", "~/Admin/UserControl/Template/Menu/ListMenu.aspx");
            //RouteTable.Routes.MapPageRoute("Add Menu", "admin/AddMenu", "~/Admin/UserControl/Template/Menu/AddMenu.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Menu", "admin/EditMenu/{ID}", "~/Admin/UserControl/Template/Menu/EditMenu.aspx");

            //RouteTable.Routes.MapPageRoute("List News", "admin/ListNews", "~/Admin/UserControl/Template/News/ListNews.aspx");
            //RouteTable.Routes.MapPageRoute("Insert News", "admin/AddNews", "~/Admin/UserControl/Template/News/InsertNews.aspx");
            //RouteTable.Routes.MapPageRoute("Update News", "admin/EditNews/{ID}", "~/Admin/UserControl/Template/News/UpdateNews.aspx");
            ////CHeck if the file path is right
            //RouteTable.Routes.MapPageRoute("List Products", "admin/ListProducts", "~/Admin/UserControl/Template/Products/ListProducts.aspx");
            //RouteTable.Routes.MapPageRoute("Insert Products", "admin/AddProducts", "~/Admin/UserControl/Template/Products/InsertProduct.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Products", "admin/EditProducts/{ID}", "~/Admin/UserControl/Template/Products/EditProduct.aspx");

            //RouteTable.Routes.MapPageRoute("List ProductType", "admin/ListProductTypes", "~/Admin/UserControl/Template/ProductType/ListProductTypes.aspx");
            //RouteTable.Routes.MapPageRoute("Add ProductType", "admin/AddProductType", "~/Admin/UserControl/Template/ProductType/AddProductType.aspx");
            //RouteTable.Routes.MapPageRoute("Edit ProductType", "admin/EditProductType/{ID}", "~/Admin/UserControl/Template/ProductType/EditProductType.aspx");

            //RouteTable.Routes.MapPageRoute("List Roles", "admin/ListRoles", "~/Admin/UserControl/Template/Roles/ListRoles.aspx");

            //RouteTable.Routes.MapPageRoute("Settings", "admin/Settings", "~/Admin/UserControl/Template/Settings/Settings.aspx");

            //RouteTable.Routes.MapPageRoute("List Source", "admin/ListSources", "~/Admin/UserControl/Template/Source/ListSources.aspx");
            //RouteTable.Routes.MapPageRoute("Add Source", "admin/AddSource", "~/Admin/UserControl/Template/Source/AddSource.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Source", "admin/EditSource/{ID}", "~/Admin/UserControl/Template/Source/EditSource.aspx");

            //RouteTable.Routes.MapPageRoute("Subscribe", "admin/Subscribe", "~/Admin/UserControl/Template/Subscribe/Subscribe.aspx");

            ////RouteTable.Routes.MapPageRoute("FileUpload", "admin/FileUpload", "~/Admin/UserControl/Template/Upload/FileUpload.aspx");

            //RouteTable.Routes.MapPageRoute("List Users", "admin/ListUsers", "~/Admin/UserControl/Template/Users/ListUsers.aspx");
            //RouteTable.Routes.MapPageRoute("Recover Password", "admin/RecoverPassword", "~/Admin/UserControl/Template/Users/RecoverPassword.aspx");
            //RouteTable.Routes.MapPageRoute("Register", "admin/Register", "~/Admin/UserControl/Template/Users/Register.aspx");
            //RouteTable.Routes.MapPageRoute("ViewMore", "admin/ViewMore", "~/Admin/UserControl/Template/Users/ViewMore.aspx");

            //RouteTable.Routes.MapPageRoute("List Widget", "admin/ListWidget", "~/Admin/UserControl/Template/Widget/ListWidget.aspx");
            //RouteTable.Routes.MapPageRoute("Add Widget", "admin/AddWidget", "~/Admin/UserControl/Template/Widget/AddWidget.aspx");
            //RouteTable.Routes.MapPageRoute("Edit Widget", "admin/EditWidget/{ID}", "~/Admin/UserControl/Template/Widget/EditWidget.aspx");




            // RouteTable.Routes.MapPageRoute("Default", "", "~/Default.aspx");
            /*RouteTable.Routes.MapPageRoute("Menu", "{Local}/m/{MenuID}/{MenuTitle}", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("Content", "{Local}/m/{MenuID}/{MenuTitle}/c/{ContentID}/{ContentTitle}", "~/Default.aspx");*/
            //TODO Album FormURL
            //RouteTable.Routes.MapPageRoute("Content", "{Local}/m/{MenuID}/{MenuTitle}/c/{ContentID}/{ContentTitle}", "~/Default.aspx");
        }
    }
}
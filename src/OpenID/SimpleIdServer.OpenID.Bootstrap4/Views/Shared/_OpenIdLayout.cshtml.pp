﻿@using $rootnamespace$.Resources

@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}

@section SubMenu {
    @if (User.Identity.IsAuthenticated)
    {
        <li class="nav-item">
            <a class="nav-link" href="@Url.Action("Manage", "Consents", new { area = "" })">
                @OpenIdGlobal.consents
            </a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="@Url.Action("Disconnect", "Home", new { area = "" })">@OpenIdGlobal.disconnect</a>
        </li>
    }
}

@section Scripts {
    @RenderSection("Scripts", required: false)
}

@RenderBody()
<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<div class="skin-toasts" aria-live="polite" aria-atomic="true">
	<div id="skin_toastBrowserAlert" class="toast hide" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false">
		<div class="toast-header">
			<i class="fas fa-exclamation-triangle text-warning"></i> <strong class="ml-1 mr-auto"><%: T.GetString ("BrowserAlert_Title.Text") %></strong>
			<button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label='<%: T.GetString ("Close.Text") %>'>
				<span aria-hidden="true">&times;</span>
			</button>
		</div>
		<div class="toast-body">
			<p><%= T.GetString ("BrowserAlert_Body.Text") %></p>
		</div>
	</div>
	<div id="skin_toastCookiesAlert" class="toast hide" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false">
		<div class="toast-header">
			<i class="fas fa-info-circle text-info"></i> <strong class="ml-1 mr-auto"><%: T.GetString ("CookiesAlert_Title.Text") %></strong>
			<button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label='<%: T.GetString ("Close.Text") %>'>
				<span aria-hidden="true">&times;</span>
			</button>
		</div>
		<div class="toast-body">
			<%= T.GetString ("CookiesAlert_Body.Text") %>
			<button type="button" class="btn btn-sm btn-info" onclick="skinCookiesAlertButtonClick(event)">
				<%= T.GetString ("CookiesAlert_Button_Label.Text") %>
			</button>
		</div>
	</div>
	<div id="skin_toastCookiesDisabledAlert" class="toast hide" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false">
		<div class="toast-header">
			<i class="fas fa-exclamation-triangle text-warning"></i> <strong class="ml-1 mr-auto"><%: T.GetString ("CookiesDisabledAlert_Title.Text") %></strong>
			<button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label='<%: T.GetString ("Close.Text") %>'>
				<span aria-hidden="true">&times;</span>
			</button>
		</div>
		<div class="toast-body">
			<%= T.GetString ("CookiesDisabledAlert_Body.Text") %>
		</div>
	</div>
</div>

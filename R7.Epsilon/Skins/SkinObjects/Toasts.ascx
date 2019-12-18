<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<div class="skn-toasts" aria-live="polite" aria-atomic="true">
	<div id="skin_toastBrowserWarning" class="toast hide" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false">
		<div class="toast-header">
			<i class="fas fa-exclamation-circle"></i> <strong class="ml-1 mr-auto"><%: T.GetString ("BrowserWarning_Title.Text") %></strong>
			<button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label='<%: T.GetString ("Close.Text") %>'>
				<span aria-hidden="true">&times;</span>
			</button>
		</div>
		<div class="toast-body">
			<p><%= T.GetString ("BrowserWarning_Body.Text") %></p>
		</div>
	</div>
	<div id="skin_toastCookiesAlert" class="toast hide" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false">
		<div class="toast-header">
			<i class="fas fa-exclamation-circle"></i> <strong class="ml-1 mr-auto"><%: T.GetString ("CookiesAlert_Title.Text") %></strong>
			<button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label='<%: T.GetString ("Close.Text") %>'>
				<span aria-hidden="true">&times;</span>
			</button>
		</div>
		<div class="toast-body">
			<p><%= T.GetString ("CookiesAlert_Body.Text") %></p>
			<button type="button" class="btn btn-sm btn-primary" onclick="skinCookiesAlertButtonClick(event)">
				<%= T.GetString ("CookiesAlert_Button_Label.Text") %>
			</button>
		</div>
	</div>
</div>

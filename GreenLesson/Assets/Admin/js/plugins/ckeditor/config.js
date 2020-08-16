/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
	// Define changes to default configuration here. For example:
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowserUrl = '/Assets/Admin/js/plugins/ckfinder/ckfinder.html';
	config.filebrowserImageBrowserUrl = '/Assets/Admin/js/plugins/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowserUrl = '/Assets/Admin/js/plugins/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Data';
	config.filebrowserFlashUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload$type=flash';
	CKFinder.setupCKEditor(null, '/Assets/Admin/js/plugins/ckfinder/');
};

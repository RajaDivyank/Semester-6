(function($) {
  'use strict';
  $(function() {
    $('.file-upload-browse').on('click', function() {
      var file = $(this).parent().parent().parent().find('.file-upload-default');
      file.trigger('click');
    });
    $('.file-upload-default').on('change', function() {
        $(this).parent().find('.form-control').val($(this).val().replace('D:\\Semester-6\\Project\\Hotel_Management\\Hotel_Management\\wwwroot\\Images', ''));
    });
  });
})(jQuery);
/*(function ($) {
    'use strict';
    $(function () {
        $('.file-upload-browsestaff').on('click', function () {
            var file = $(this).parent().parent().parent().find('.file-upload-defaultstaff');
            file.trigger('click');
        });
        $('.file-upload-defaultstaff').on('change', function () {
            $(this).parent().find('.form-control').val($(this).val().replace('D:\\Semester-6\\Project\\Hotel_Management\\Hotel_Management\\wwwroot\\Images', ''));
        });
    });
})(jQuery);
(function ($) {
    'use strict';
    $(function () {
        $('.file-upload-browseID').on('click', function () {
            var file = $(this).parent().parent().parent().find('.file-upload-defaultID');
            file.trigger('click');
        });
        $('.file-upload-defaultID').on('change', function () {
            $(this).parent().find('.form-control').val($(this).val().replace('D:\\Semester-6\\Project\\Hotel_Management\\Hotel_Management\\wwwroot\\Images', ''));
        });
    });
})(jQuery);*/
(function() {
  var DetailPartial;

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    $('#RegionPartialTop .partialLoad').click(function() {
      var eleId;
      eleId = $(this).addClass('waiting').attr('id');
      return $.post('/Articles/' + eleId + '/Post', {
        name: 'John Doe',
        email: 'a@a.com'
      }, function(result) {
        var top;
        top = $('#' + eleId).closest('.partialTop');
        return top.html($(result)).find('.collapser').click(function() {
          return $(this).toggleClass('expanded').next().toggle();
        });
      });
    });

    return DetailPartial;

  })();

}).call(this);

(function() {
  var DetailPartial, Partial, detailPartial;

  Partial = (function() {

    Partial.name = 'Partial';

    function Partial() {}

    Partial.GetInputVal = function(selector) {
      var ele, r;
      ele = $(selector);
      r = '';
      if (ele.length !== 0) {
        return r = ele.val();
      }
    };

    Partial.AttachCollapser = function(controller) {
      return $('#' + controller + 'Top .collapser').unbind('click').click(function() {
        return $(this).toggleClass('expanded').next().toggle();
      });
    };

    return Partial;

  })();

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    DetailPartial.prototype.AttachGet = function() {
      return $('#DetailPartialTop .partialGet').unbind('click').click(function() {
        var controller, params;
        $(this).addClass('waiting');
        controller = 'DetailPartial';
        params = {
          name: ''
        };
        return $.get('/Articles/' + controller + '/Get', params, function(result) {
          return (new DetailPartial).PostPost(result, controller);
        });
      });
    };

    DetailPartial.prototype.AttachPost = function() {
      return $('#DetailPartialTop .partialPost').unbind('click').click(function() {
        var name, params, title, url;
        $(this).addClass('waiting');
        name = Partial.GetInputVal('.DetailPartial-Name');
        title = Partial.GetInputVal('.DetailPartial-Title');
        url = Partial.GetInputVal('.DetailPartial-Url');
        params = {
          name: name,
          Title: title,
          Url: url,
          LockedBy: '',
          status: '',
          assignedTo: ''
        };
        return (new DetailPartial).Post('DetailPartial', params);
      });
    };

    DetailPartial.prototype.Post = function(controller, params) {
      return $.post('/Articles/' + controller + '/Post', params, function(result) {
        return (new DetailPartial).PostPost(result, controller);
      });
    };

    DetailPartial.prototype.PostPost = function(results, eleId) {
      $('#' + eleId + 'Top').closest('.partialTop').html($(results));
      Partial.AttachCollapser('DetailPartial');
      return (new DetailPartial).AttachPost();
    };

    return DetailPartial;

  })();

  detailPartial = new DetailPartial;

  detailPartial.AttachGet();

}).call(this);

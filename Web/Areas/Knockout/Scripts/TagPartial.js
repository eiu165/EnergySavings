


$(function () {
    function Tag(data) {
        this.name = ko.observable(data.name);
        this.isInArticle = ko.observable(data.isInArticle);
    }

    function TagListViewModel() {
        // Data
        var self = this;
        self.tags = ko.observableArray([]);
        self.newTagText = ko.observable();
        self.existingtags = ko.computed(function () {
            return ko.utils.arrayFilter(self.tags(), function (tag) { return tag.isInArticle() && !tag._destroy; });
        });
        // Operations
        self.addTag = function () {
            self.newTagText($("#TagPartial #txtTag").val());
            var newTag = new Tag({ name: self.newTagText(), isInArticle: true });
            //self.tags.push(newTag);
            self.newTagText("");
            self.save(newTag);
        };
        self.MapData = function (allData) {
            var mappedtags = $.map(allData, function (item) { return new Tag(item); });
            self.tags(mappedtags);
            self.configureTagAutocomplete();
        };
        self.removeTag = function (tag) {
            $('#TagPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            self.tags.destroy(tag);
            $.ajax("/Knockout/Main/RemoveTag", {
                data: ko.toJSON({ tag: tag }),
                type: "post", contentType: "application/json",
                success: function (allData) {
                    self.MapData(allData);
                },
                error: function () { alert('error'); },
                complete: function () {
                    $('#TagPartial').unblock();
                }
            });

        };
        self.save = function (newTag) {
            $('#TagPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            $.ajax("/Knockout/Main/SaveTag", {
                data: ko.toJSON({ tag: newTag }),
                type: "post", contentType: "application/json",
                success: function (allData) {
                    self.MapData(allData);
                },
                error: function () { alert('error'); },
                complete: function () { $('#TagPartial').unblock(); }
            });
        };
        self.cancel = function () {
            self.load();
        };
        self.load = function () {
            $('#TagPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            // Load initial state from server, convert it to Tag instances, then populate self.tags 
            $.getJSON("/Knockout/Main/GetTags", function (allData) {
                $('#TagPartial').unblock();
                self.MapData(allData);
            });
        };
        self.configureTagAutocomplete = function () {
            var availableTags = $.map(self.tags(), function (item) { return (item.name._latestValue); });
            $("#TagPartial #txtTag").autocomplete({
                source: availableTags
            });
        };
        self.load();
    }

    ko.applyBindings(new TagListViewModel(), $('#TagPartial')[0]);

});


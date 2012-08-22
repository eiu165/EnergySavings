


$(function () {
    function Article(data) {
        this.name = ko.observable(data.name);
        this.id = ko.observable(data.id); 
    }

    function ArticleListViewModel() {
        // Data
        var self = this;
        self.articles = ko.observableArray([]);
        self.MapData = function (allData) {
            var mappedtags = $.map(allData, function (item) { return new Article(item); });
            self.articles(mappedtags);
        }; 
        self.deleteArticle = function (article) {
            $('#ArticlePartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            self.articles.destroy(article);
            $.ajax("/Knockout/Articles/DeleteArticle", {
                data: ko.toJSON({ article: article }),
                type: "post", contentType: "application/json",
                success: function (allData) {self.MapData(allData);},
                error: function () { alert('error'); },
                complete: function () {$('#ArticlePartial').unblock();}
            }); 
        };
        self.load = function () {
            $('#ArticlePartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            // Load initial state from server, convert it to Tag instances, then populate self.tags 
            $.getJSON("/Knockout/Articles/GetArticles", function (allData) {
                $('#ArticlePartial').unblock();
                self.MapData(allData);
            });
        };
        self.load();
    }

    ko.applyBindings(new ArticleListViewModel(), $('#ArticlePartial')[0]);

});


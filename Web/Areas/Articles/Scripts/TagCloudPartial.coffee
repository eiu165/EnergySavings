class DetailPartial
	$('#TagCloudPartialTop .partialLoad').click ->  
		eleId = $(this).addClass('waiting').attr('id')
		$.post '/Articles/'+eleId+'/Post',  
			name: 'John Doe'
			email: 'a@a.com'
			(result) ->  
				top = $('#'+eleId).closest('.partialTop')  
				top.html($(result)).find('.collapser').click ->  
					$(this).toggleClass('expanded').next().toggle();

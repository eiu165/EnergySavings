
class Partial
	@GetInputVal: (selector) -> 
		ele = $(selector) 
		r = '' 
		if(ele.length != 0)   
			r = ele.val() 
			
	@AttachCollapser: (controller)  -> 
		$('#'+controller+'Top .collapser').unbind('click').click ->  
			$(this).toggleClass('expanded').next().toggle();


class DetailPartial 
	AttachGet:  -> 
		$('#DetailPartialTop .partialGet').unbind('click').click -> 
			$(this).addClass('waiting')
			controller = 'DetailPartial'
			params = {name: '' } 
			$.get('/Articles/'+ controller+'/Get',
			params
			(result) ->  
				(new DetailPartial).PostPost(result, controller))  
	AttachPost:  ->  
		$('#DetailPartialTop .partialPost').unbind('click').click ->  
			$(this).addClass('waiting')
			name = Partial.GetInputVal('.DetailPartial-Name') 
			title = Partial.GetInputVal('.DetailPartial-Title') 
			url = Partial.GetInputVal('.DetailPartial-Url') 
			params = {name: name, Title: title,   Url: url,   LockedBy: '',   status: '',   assignedTo: ''}  
			(new DetailPartial).Post('DetailPartial' ,  params )  
	Post: (controller, params) ->  
		$.post('/Articles/'+controller+'/Post',
		params
		(result) ->  
			(new DetailPartial).PostPost(result, controller))  
	PostPost: (results, eleId) ->  
		$('#'+eleId+'Top').closest('.partialTop').html($(results))  
		Partial.AttachCollapser('DetailPartial')
		(new DetailPartial).AttachPost() 

detailPartial = new DetailPartial 
detailPartial.AttachGet() 
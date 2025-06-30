using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController(IMessageService _messageService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var messages = _messageService.TGetAll();
            var results = _mapper.Map<List<ResultMessageDto>>(messages);
            return View(results);
        }

        public IActionResult Delete(int id)
        {
            var message = _messageService.TGetById(id);
            if (message != null)
            {
                _messageService.TDelete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Update(int id)
        {
            var message = _messageService.TGetById(id);
            if (message != null)
            {
                var result = _mapper.Map<UpdateMessageDto>(message);
                return View(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<Message>(updateMessageDto);
                _messageService.TUpdate(message);
                return RedirectToAction("Index");
            }
            return View(updateMessageDto);
        }

        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<Message>(createMessageDto);

                _messageService.TCreate(message);
                return RedirectToAction("Index");
            }
            return View(createMessageDto);
        }

        public IActionResult DetailMessage(int id)
        {
            var message = _messageService.TGetById(id);
            var result = _mapper.Map<DetailMessageDto>(message);

            return View(result);

        }


        
    }
}

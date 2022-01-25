#nullable disable
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.ViewModels;

namespace Store.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhoneService _phoneService;

        // temp
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PhoneDTO, PhoneViewModel>();
            cfg.CreateMap<PhoneSpecificationsDTO, PhoneViewModel>().ForMember(s => s.Id, 
                opt => opt.Ignore());
        }).CreateMapper();

        public PhonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        // GET: Phones
        public  ActionResult Index()
        {
            var phoneDtos = _phoneService.GetAll();
            return View(_mapper.Map<List<PhoneViewModel>>(phoneDtos));
        }
        
        // GET: Phones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = _phoneService.GetItemWithInclude(id, p => p.Specifications);

            if (phone == null)
            {
                return NotFound();
            }

            var phones = _phoneService.GetWithFiltersAndInclude(
                        p => p.Brand.Name == phone.Brand && p.Model == phone.Model && p.Id != phone.Id,
                        ph => ph.Specifications);

            var model = _mapper.Map<PhoneViewModel>(phone);
            _mapper.Map(phone.Specifications, model);
            
            var modelList = _mapper.Map<List<PhoneViewModel>>(phones);
            modelList.Insert(0, model);
        
            return View(modelList);
        }
        //
        // // GET: Phones/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }
        //
        // // POST: Phones/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Make,Model,Memory,Color,ColorHex,Price,Amount,Image,Id")] Phone phone)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(phone);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(phone);
        // }
        //
        // // GET: Phones/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var phone = await _context.Phones.FindAsync(id);
        //     if (phone == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(phone);
        // }
        //
        // // POST: Phones/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Make,Model,Memory,Color,ColorHex,Price,Amount,Image,Id")] Phone phone)
        // {
        //     if (id != phone.Id)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(phone);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!PhoneExists(phone.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(phone);
        // }
        //
        // // GET: Phones/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var phone = await _context.Phones
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (phone == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(phone);
        // }
        //
        // // POST: Phones/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var phone = await _context.Phones.FindAsync(id);
        //     _context.Phones.Remove(phone);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }
        //
        // private bool PhoneExists(int id)
        // {
        //     return _context.Phones.Any(e => e.Id == id);
        // }
    }
}

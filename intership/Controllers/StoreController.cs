using AutoMapper;
using intership.Data;
using intership.DTO;
using intership.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _repository;

        private readonly IMapper _mapper;

        public StoreController(IMapper mapper, IStoreRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/stores/{id}
        [HttpGet("/{id}")]
        public ActionResult<StoreReadDTO> GetStoreById(Guid id)
        {
            var store = _repository.GetStoreById(id);
            if (store != null)
            {
                return Ok(_mapper.Map<StoreReadDTO>(store));
            }
            return NotFound();
        }
        //GET api/stores
        [HttpGet]
        public ActionResult<IEnumerable<StoreReadDTO>> GetAllStores()
        {
            var store = _repository.GetAllStores();

            return Ok(_mapper.Map<IEnumerable<StoreReadDTO>>(store));
        }
        //GET api/stores/city/{keyword}
        [HttpGet("city/{keyword}")]
        public ActionResult<StoreReadDTO> GetStoresByCity(string keyword)
        {
            var store = _repository.GetStoreMatchingCity(keyword);
            if (store != null)
            {
                return Ok(_mapper.Map<StoreReadDTO>(store));
            }
            return NotFound();
        }
        //GET api/stores/country/{keyword}
        [HttpGet("country/{keyword}")]
        public ActionResult<StoreReadDTO> GetStoresByCountry(string keyword)
        {
            var store = _repository.GetStoreMatchingCountry(keyword);
            if (store != null)
            {
                return Ok(_mapper.Map<StoreReadDTO>(store));
            }
            return NotFound();
        }

        //DELETE api/stores/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var store = _repository.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            _repository.DeleteStore(store);
            return NoContent();
        }
        [HttpGet("/oldest")]
        public ActionResult<StoreReadDTO> GetOldestStore()
        {
            var store = _repository.GetOledestStore();
            if (store != null)
                return Ok(_mapper.Map<StoreReadDTO>(store));
            else
                return NoContent();
        }

        [HttpPost]
        public ActionResult<StoreCreateDTO> CreateProduct(StoreCreateDTO _storeCreateDTO)
        {
            var store = _mapper.Map<Store>(_storeCreateDTO);
            _repository.CreateStore(store);

            var storeReadDto = _mapper.Map<StoreReadDTO>(store);
            return CreatedAtRoute(nameof(GetStoreById), new { id = storeReadDto.id }, storeReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult<StoreUpdateDTO> UpdateProduct(Guid id, StoreUpdateDTO storeUpdateDTO)
        {
            var storeModel = _repository.GetStoreById(id);
            if (storeModel == null)
            {
                return NotFound();
            }
            _mapper.Map(storeUpdateDTO, storeModel);
            _repository.UpdateStore(storeModel);

            return NoContent();
        }
        [HttpPut("updateOwnership{name}")]
        public ActionResult<StoreUpdateDTO> UpdateOwnership(Guid id,string name, StoreUpdateDTO storeUpdateDTO)
        {
            var storeModel = _repository.GetStoreById(id);
            if (storeModel == null)
            {
                return NotFound();
            }
            storeModel.OwnerName = name;
            _mapper.Map(storeUpdateDTO, storeModel);
            _repository.UpdateStore(storeModel);
            var storeReadDTO = _mapper.Map<StoreReadDTO>(storeModel);
            return Ok(storeReadDTO);
        }
        [HttpGet("/sortedByIncome")]
        public ActionResult<StoreReadDTO> SortByIncome()
        {
            var store = _repository.GetAllStores();
            
            store.ToList().OrderBy(s => s.MonthlyIncome);

            return Ok(_mapper.Map<StoreReadDTO>(store));
        }
        [HttpGet("/sortedByKeyword")]
        public ActionResult<StoreReadDTO> SortByKeyword(string name)
        {
            var store = _repository.GetAllStores();

            store.ToList().Where(s => s.Name == name);

            return Ok(_mapper.Map<StoreReadDTO>(store));
        }
    }
}

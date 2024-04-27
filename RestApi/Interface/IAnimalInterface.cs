using RestApi.DTO;
using RestApi.Model;

namespace RestApi.Interface;

public interface IAnimalService
{
    List<AnimalOutputDto> GetAnimals(string orderBy);
    void CreateAnimal(AnimalInputDto animal);
    void UpdateAnimal(int id, AnimalInputDto animal);
    void DeleteAnimal(int id);
}

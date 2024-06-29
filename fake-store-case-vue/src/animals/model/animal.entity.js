export class Animal {
    constructor(
        id = '',
        name = '',
        species = '',
        family = '',
        habitat = '',
        place_of_found = '',
        diet = '',
        description = '',
        weight_kg = 0,
        height_cm = 0,
        image = '') {
        this.id = id; //
        this.name = name;//
        this.species = species; //
        this.family = family;//
        this.habitat = habitat;//
        this.place_of_found = place_of_found;
        this.diet = diet;
        this.description = description;//
        this.weight_kg = weight_kg;
        this.height_cm = height_cm;
        this.image = image;
    }
}
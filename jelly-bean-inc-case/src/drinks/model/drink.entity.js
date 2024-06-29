export class Drink {
    constructor(
        beanId = '',
        backgroundColor = '',
        ingredients = [],
        flavorName = '',
        description = '',
        imageUrl = null,
        glutenFree = false,
        sugarFree = false,
        seasonal = false,
        kosher = false
    ) {
        this.beanId = beanId; //
        this.backgroundColor = backgroundColor; //
        this.ingredients = ingredients; //
        this.flavorName = flavorName;//
        this.description = description; //
        this.imageUrl = imageUrl; //
        this.glutenFree = glutenFree;
        this.sugarFree = sugarFree;
        this.seasonal = seasonal;
        this.kosher = kosher;
    }
}
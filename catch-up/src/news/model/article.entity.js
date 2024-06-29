export class Article {

    constructor(
        title = '',
        description = '',
        url = '',
        urlToImage = '',
        source = null
    ) {
        this.title = title;
        this.description = description;
        this.url = url;
        this.urlToImage = urlToImage;
        this.source = source;
    }

}
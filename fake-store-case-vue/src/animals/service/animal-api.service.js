import axios from "axios";

const http = axios.create({
    baseURL: 'https://freetestapi.com/api/v1'
});

export class AnimalApiService {

    getAllAnimals(limit = 10) {
        return http.get(`/animals?limit=${limit}`);
    }
}
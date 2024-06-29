import httpService from "../../shared/services/http-service.js";

export class PatientApiService {

    get(id) {
        return httpService.get(`/patients/${id}`);
    }
}
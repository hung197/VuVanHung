import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ThanhphoService {

  constructor(private http: HttpClient) { }
  getThanhPhoList() {
    return this.http.get(environment.apiBaseURI + '/ThanhPho');
  }
  postThanhPho(formData) {
    return this.http.post(environment.apiBaseURI + '/ThanhPho', formData);
  }
  PutThanhPho(formData) {
    return this.http.put(environment.apiBaseURI + '/ThanhPho/' + formData.MaTp, formData);
  }
  DeleteThanhPho(id) {
    return this.http.delete(environment.apiBaseURI + '/ThanhPho/' + id);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class rentaexentaService {


     public baseUrl: string = "http://192.168.160.189:9095/api/";
  // public baseUrl: string= "https://localhost:44386/api/"
  // public baseUrl: string= "https://localhost:5001/api/"
  constructor(
    private http: HttpClient
  ) { }

  getRentaExenta() {
    return this.http.get<any[]>(`${this.baseUrl}rentaexenta`);
  }


  postRentaExenta(id: string, changes: Partial<any>) {
    return this.http.post(`${this.baseUrl}rentaexenta/${id}`, changes);
  }




  /*getVariables(id: string) {
    return this.http.get<any>(`${this.baseUrl}Variable/${id}`);
  }

 

  updateVariables(id: string, changes: Partial<any>) {
    return this.http.put(`${this.baseUrl}Variable/${id}`, changes);
  }

  deleteVariables(id: string) {
    return this.http.delete(`${this.baseUrl}Variable/${id}`);
  }*/
}
   

import { Injectable } from '@angular/core';
// tslint:disable-next-line: import-blacklist
import { Observable } from 'rxjs';

import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class EmpleadosService {
    private va_arrayEndPoints: any;
    constructor(
        private _http: HttpClient,) {
    }

    public baseUrl: string = "http://192.168.160.189:9095/api/";
  //  public baseUrl: string= "https://localhost:44386/api/"
   //public baseUrl: string= "https://localhost:5001/api/"


    getAllEmpleado(): Observable<any> {
        let url = this.baseUrl + 'Empleado';
        return this._http.get( url)
    }

    getEmpleado(id: string) {
        return this._http.get<any>(`${this.baseUrl}Empleado/${id}`);
      }
    /* 
    pushAssetsType(info): Observable<any> {
        let url = '' + 'api/v1/assets_type';
        let header = new HttpHeaders()
        header.append("Content-Type", "application/json")
        return this._http.put(url, info, {
            headers: header
        }).map(res => res.json())
    }



    updateTypeAssets(id, info): Observable<any> {
        let url = '' + `api/v1/assets_type?id=${id}`;
        let header = new HttpHeaders()
        header.append("Content-Type", "application/json")
        return this._http.post(url, info, {
            headers: header
        }).map(res => res.json())
    }
 */



}

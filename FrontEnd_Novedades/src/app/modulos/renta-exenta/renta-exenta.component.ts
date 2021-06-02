import { HttpClient } from '@angular/common/http';
import { TemplateRef } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { rentaexentaService } from 'src/app/services/renta-exenta.service'
import { deducionesService } from 'src/app/services/deduciones.service';

import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-renta-exenta',
  templateUrl: './renta-exenta.component.html',
  styleUrls: ['./renta-exenta.component.css']
})
export class RentaExentaComponent implements OnInit {

  displayedColumns: string[] = ['nombre', 'aft', 'pensionVoluntaria', 'rentaExenta', 'total'];
  dataSource;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  modalRef: BsModalRef;
  modalRefEditar: BsModalRef;

  public rentaExenta: any;
  public empleados: any;
  public empleadoSelect: any;
  public salario: 0;
  public postRentaExenta = {
    aft: 0,
    pensionVoluntaria: 0,
    rentaexenta: 0
  };


  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private http: HttpClient,
    private _http: HttpClient,
    private modalService: BsModalService,
    private deducionesService: deducionesService,
    private rentaexentaService: rentaexentaService) {
    this.fetchdeduciones();
    this.getAllEmpleados()
  }

  ngOnInit(): void {
  }

  fetchdeduciones() {
    this.rentaexentaService.getRentaExenta()
      .subscribe(result => {
        this.rentaExenta = result
        this.dataSource = new MatTableDataSource<any>(this.rentaExenta);
        this.dataSource.paginator = this.paginator;
        console.log(result)
      });
  }

  /*saveRenataExenta() {
    this.rentaexentaService.postRentaExenta(this.postRentaExenta)
    .subscribe((newProduct) => {
      console.log(newProduct);
      this.fetchdeduciones();
    });
  }*/

  getAllEmpleados() {
    this.deducionesService.getAllVariables().subscribe(result => {
      this.empleados = result;
      console.log(result);
    }, error => console.error(error));

  }

  guardar() {

    let body = {

      "aft": this.postRentaExenta.aft,
      "pensionVoluntaria": this.postRentaExenta.pensionVoluntaria,
      "rentaexenta": ((this.salario-this.postRentaExenta.rentaexenta-this.postRentaExenta.aft-this.postRentaExenta.pensionVoluntaria)*0.25)
    }
    console.log();
    this.rentaexentaService.postRentaExenta(this.empleadoSelect.id, body).subscribe(result => {
      console.log("resul", result);
      this.fetchdeduciones()
    }, error => console.error(error));
  }

  calculos2() {
    console.log((this.empleadoSelect.total));
    this.postRentaExenta.rentaexenta = (this.empleadoSelect.total);
  }
}

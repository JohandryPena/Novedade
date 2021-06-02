import { AfterViewInit, ChangeDetectorRef, Component, TemplateRef, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2';
import { FormGroup, FormControl } from '@angular/forms';

import { deducionesService } from 'src/app/services/deduciones.service';
import { EmpleadosService } from 'src/app/services/empleados.service';
import { HttpClient } from '@angular/common/http';





@Component({
  selector: 'app-deduciones',
  templateUrl: './deduciones.component.html',
  styleUrls: ['./deduciones.component.css']
})

export class DeducionesComponent implements OnInit {

  displayedColumns: string[] = ['nombre', 'intereses de vivienda', 'Medic. Prepagada', 'Dependientes', 'Total deducciones'];
  dataSource;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  modalRef: BsModalRef;
  modalRefEditar: BsModalRef;

  public deduciones: any;
  public empleados: any;
  public empleadoSelect:any;

  public postDeduciones =
    {
      interesVivienda: 0,
      prepagada: 0,
      dependiente: 0
    };

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private http: HttpClient,
    private _http: HttpClient,
    private modalService: BsModalService,
    private deducionesService: deducionesService,
    private empleadosService: EmpleadosService
  ) {
    this.fetchdeduciones();
    this.getAllEmpleados();
  }

  ngOnInit(): void {
  }

  fetchdeduciones() {
    this.deducionesService.getAllVariables()
      .subscribe(result => {
        this.deduciones = result
        this.dataSource = new MatTableDataSource<any>(this.deduciones);
        this.dataSource.paginator = this.paginator;
        console.log(result)
      });
  }
  getAllEmpleados() {
    this.empleadosService.getAllEmpleado().subscribe(result => {
      this.empleados = result;
    }, error => console.error(error));

  }


  guardar() {

    let body = {
      "interesVivienda": this.postDeduciones.interesVivienda,
      "prepagada": this.postDeduciones.prepagada,
      "dependiente": this.postDeduciones.dependiente
    }
 
    this.deducionesService.postDeduciones(this.empleadoSelect.id,body).subscribe(result => {
      console.log("resul", result);
      this.salirModal()
      this.fetchdeduciones()
    }, error => console.error(error));
  }

  salirModal(){
    this.postDeduciones.interesVivienda = 0;
    this.postDeduciones.dependiente = 0;
    this.postDeduciones.prepagada = 0;
  }

}

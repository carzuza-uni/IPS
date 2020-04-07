import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Paciente } from '../pulsacion/models/paciente';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
   }

  post(paciente: Paciente): Observable<Paciente>{
    return this.http.post<Paciente>(this.baseUrl + 'api/Paciente', paciente)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Paciente>('Registrar paciente', null))
      );
  }

  get(): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(this.baseUrl + 'api/Paciente')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<Paciente[]>('Consulta paciente', null))
      );
  }
}

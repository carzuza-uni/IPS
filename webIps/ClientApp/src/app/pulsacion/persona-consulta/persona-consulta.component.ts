import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from 'src/app/services/persona.service';
import { Paciente } from '../models/paciente';
import { PacienteService } from 'src/app/services/paciente.service';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
  personas:Persona[];
  pacientes: Paciente[];
  searchText:string;

  constructor(private pacienteService: PacienteService) { }

  ngOnInit() {
    this.pacienteService.get().subscribe(result => {
      this.pacientes = result;
    }) 
  }

  get(){
    //this.personas = this.personaService.get();
  }

}

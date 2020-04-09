import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from '../../services/persona.service';
import { Paciente } from '../models/paciente';
import { PacienteService } from 'src/app/services/paciente.service';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  persona: Persona;
  paciente: Paciente;

  //validacion
  enviarDatos = false;
  errorIdentificacion = false;
  errorNombre = false;
  errorEdad = false;
  errorSexo = false;
  
  constructor(private personaService: PersonaService, private pacienteService: PacienteService) { }

  ngOnInit() {
    this.paciente = new Paciente();
    this.persona = new Persona;
  }

  add(){
    this.pacienteService.post(this.paciente).subscribe(p => {
      if (!p) {
        this.paciente.identificacion = '';
        this.paciente.nombre = '';
        this.paciente.valorServicio = null;
        this.paciente.salario = null;
        this.paciente.copago = null;
        alert('Registro realizado con exito!');
      }
    });
  }

  add1(){    
    //$('#mensaje').addClass("hide");
    this.errorIdentificacion = false;
    this.errorNombre = false;
    this.errorEdad = false;
    this.errorSexo = false;
    this.enviarDatos = true;
		let validar = true;
		if(!this.persona.identificacion){
      validar = false;
      this.errorIdentificacion = true;
		}
		if(!this.persona.nombre){
      validar = false;
      this.errorNombre = true;
		}
		if(!this.persona.edad){
      validar = false;
      this.errorEdad = true;
		}
		if(!this.persona.sexo){
      validar = false;
      this.errorSexo = true;
		}
		if(!validar){
			return false;
    }
    let pulsacion = 0;
		if (this.persona.sexo == "F"){
      pulsacion = (210 - this.persona.edad) / 10;
    }else if (this.persona.sexo == "M"){
      pulsacion = (220 - this.persona.edad) / 10;
    }else{
      pulsacion = 0;
    }
    this.persona.pulsacion = pulsacion;
    this.personaService.post(this.persona);
    alert('Se agrego una nueva persona: '+ JSON.stringify(this.persona));
  }

}

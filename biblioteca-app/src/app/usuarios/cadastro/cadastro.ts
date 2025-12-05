import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  imports: [ReactiveFormsModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.css',
})
export class CadastroComponent {

  cadastroForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.cadastroForm = this.fb.group({
      nomeCompleto: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(8)]]
    });
  }

  onSubmit() {
    if(this.cadastroForm.valid) {
      const dadosCadastro = this.cadastroForm.value;
      console.log('Formulário Válido, pronto para enviar!', dadosCadastro);
    
    } else {
      console.error('Formulário Inválido');
    }
  }
}

import { Component } from '@angular/core';
import { UsuariosService } from '../../services/usuarios.service';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  imports: [ReactiveFormsModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.css',
})
export class CadastroComponent {

  cadastroForm: FormGroup;

  constructor(private fb: FormBuilder, private usuariosService: UsuariosService) {
    this.cadastroForm = this.fb.group({
      nomeCompleto: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(8)]],
      cep: ['', Validators.required],
      rua: ['', Validators.required],
      cidade: ['', Validators.required],
      estado: ['', Validators.required]
    });
  }

  onSubmit() {
    if(this.cadastroForm.valid) {
      const dadosCadastro = this.cadastroForm.value;
      console.log('Formulário Válido, pronto para enviar!', dadosCadastro);

      this.usuariosService.cadastrarUsuario(dadosCadastro)
        .subscribe({
          next: (response) => {
            console.log('Cadastro efetuado com sucesso!', response);

          },
          error: (error) => {
            console.error('Erro no servidor:', error);
            
          }
        })
    
    } else {
      console.error('Formulário Inválido');
    }
  }
}

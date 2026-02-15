import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LibroService } from './libro.service';
import { Libro } from './libro.model';
import { Autor } from '../autores/autor.model';
import { TipoLibro } from '../TipoLibros/tipo-libro.model';

@Component({
  selector: 'app-libros',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './libros.component.html'
})
export class LibrosComponent implements OnInit {

  libros: Libro[] = [];
  autores: Autor[] = [];
  tipos: TipoLibro[] = [];

  editando = false;

  nuevoLibro: Libro = {
    IdLibro: 0,
    Titulo: '',
    Precio: 0,
    Stock: 0,
    IdAutor: 0,
    IdTipo: 0
  };

  constructor(private libroService: LibroService) {}

  ngOnInit() {
        this.libroService.getLibros().subscribe(data => {
        console.log("DATOS QUE LLEGAN:", data);
        this.libros = data;
        });
    }


  cargarLibros() {
    this.libroService.getLibros().subscribe(data => {
      this.libros = data;
    });
  }

  cargarAutores() {
    this.libroService.getAutores().subscribe(data => {
      this.autores = data;
    });
  }

  cargarTipos() {
    this.libroService.getTipos().subscribe(data => {
      this.tipos = data;
    });
  }

  guardarLibro() {
    if (this.editando) {
      this.libroService.updateLibro(this.nuevoLibro.IdLibro, this.nuevoLibro)
        .subscribe(() => {
          this.cargarLibros();
          this.cancelar();
        });
    } else {
      this.libroService.createLibro(this.nuevoLibro)
        .subscribe(() => {
          this.cargarLibros();
          this.limpiar();
        });
    }
  }

  editar(libro: Libro) {
    this.nuevoLibro = { ...libro };
    this.editando = true;
  }

  eliminar(id: number) {
    this.libroService.deleteLibro(id)
      .subscribe(() => this.cargarLibros());
  }

  cancelar() {
    this.editando = false;
    this.limpiar();
  }

  limpiar() {
    this.nuevoLibro = {
      IdLibro: 0,
      Titulo: '',
      Precio: 0,
      Stock: 0,
      IdAutor: 0,
      IdTipo: 0
    };
  }
}

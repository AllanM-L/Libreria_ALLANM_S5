import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Libro } from './libro.model';
import { Autor } from '../autores/autor.model';
import { TipoLibro } from '../TipoLibros/tipo-libro.model';

@Injectable({
  providedIn: 'root'
})
export class LibroService {

  private apiUrl = 'https://localhost:7074/api/Libros   ';

  constructor(private http: HttpClient) { }

  // LIBROS
  getLibros(): Observable<Libro[]> {
    return this.http.get<Libro[]>(`${this.apiUrl}/libros`);
  }

  createLibro(libro: Libro): Observable<any> {
    return this.http.post(`${this.apiUrl}/libros`, libro);
  }

  updateLibro(id: number, libro: Libro): Observable<any> {
    return this.http.put(`${this.apiUrl}/libros/${id}`, libro);
  }

  deleteLibro(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/libros/${id}`);
  }

  // AUTORES
  getAutores(): Observable<Autor[]> {
    return this.http.get<Autor[]>(`${this.apiUrl}/autores`);
  }

  // TIPOS
  getTipos(): Observable<TipoLibro[]> {
    return this.http.get<TipoLibro[]>(`${this.apiUrl}/Tipolibros`);
  }
}


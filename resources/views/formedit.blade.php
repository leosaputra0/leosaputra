@extends('layouts.main')
@section('title', 'eMaha - Form Edit Student')
@section('content')
    <div class="card mt-4">
        <div class="card-header">
            <strong>Form Edit Student</strong>
        </div>
        <div class="card-body">
            @php
                $minat = explode(',', $mhs->minat);
            @endphp
            <form action="/student/update/{{ $mhs->id }}" method="POST">
                @csrf
                @method('PUT')
                <div class="form-group">
                    <label>NIM</label>
                    <input type="number" name="nim" class="form-control" value="{{ $mhs->nim }}" readonly>
                </div>

                <div class="form-group">
                    <label>Nama</label>
                    <input type="text" name="nama" class="form-control" value="{{ $mhs->nama }}">
                </div>

                <label>Gender</label>
                <div class="form-check">
                    <input type="radio" name="gender" class="form-check-input" value="Pria"
                        {{ $mhs->gender == 'Pria' ? 'checked' : '' }}>
                    <label>Pria</label>
                </div>
                <div class="form-check">
                    <input type="radio" name="gender" class="form-check-input" value="Wanita"
                        {{ $mhs->gender == 'Wanita' ? 'checked' : '' }}>
                    <label>Wanita</label>
                </div>

                <label>Program Studi</label>
                <div class="form-group">
                    <select name="prodi" class="form-control">
                        <option value="0">--Pilih Program Studi--</option>
                        <option value="Sistem Informasi" {{ $mhs->prodi == 'Sistem Informasi' ? 'selected' : '' }}>Sistem
                            Informasi</option>
                        <option value="Informatika" {{ $mhs->prodi == 'Informatika' ? 'selected' : '' }}>Informatika
                        </option>
                    </select>
                </div>

                <label>Minat</label>
                <div class="form-check">
                    <input type="checkbox" name="minat[]" class="form-check-input" value="AI"
                        {{ in_array('AI', $minat) ? 'checked' : '' }}>
                    <label>Artificial</label>
                </div>
                <div class="form-check">
                    <input type="checkbox" name="minat[]" class="form-check-input" value="Web Design"
                        {{ in_array('Web Design', $minat) ? 'checked' : '' }}>
                    <label>Web Design</label>
                </div>
                <div class="form-check">
                    <input type="checkbox" name="minat[]" class="form-check-input" value="Database"
                        {{ in_array('Database', $minat) ? 'checked' : '' }}>
                    <label>Database</label>
                </div>

                <div class="form-group mt-4">
                    <button type="submit" role="button" class="btn btn-primary">Submit</button>
                </div>
            </form>
        </div>
    </div>
@endsection

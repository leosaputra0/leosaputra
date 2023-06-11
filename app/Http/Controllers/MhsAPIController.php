<?php

namespace App\Http\Controllers;

use App\Mahasiswa;
use Illuminate\Http\Request;

class MhsAPIController extends Controller
{
    public function read()
    {
        $mhs = Mahasiswa::all();
        return response()->json([
            'success' => true,
            'message' => "Data berhasil ditampilkan",
            'data' => $mhs
        ], 200);
    }

    public function create(Request $request)
    {
        $mhs = Mahasiswa::create([
            'nim' => $request->nim,
            'nama' => $request->nama,
            'gender' => $request->gender,
            'prodi' => $request->prodi,
            'minat' => $request->minat
        ]);
        
        if($mhs){
            return response()->json([
                'success' => true,
                'message' => "Data berhasil ditambahkan"
            ],200);    
        }else{
            return response()->json([
                'success' => false,
                'message' => "Data gagal ditambahkan"
            ],400);    
        }
    }

    public function update($id, Request $request)
    {
        $mhs = Mahasiswa::find($id)->update([
            'nim' => $request->nim,
            'nama' => $request->nama,
            'gender' => $request->gender,
            'prodi' => $request->prodi,
            'minat' => $request->minat
        ]);

        if($mhs){
            return response()->json([
                'success' => true,
                'message' => "Data berhasil diubah"
            ],200);    
        }else{
            return response()->json([
                'success' => false,
                'message' => "Data gagal diubah"
            ],400);    
        }
    }

    public function delete($id)
    {
        $mhs = Mahasiswa::find($id)->delete();

        if($mhs){
            return response()->json([
                'success' => true,
                'message' => "Data berhasil dihapus"
            ],200);    
        }else{
            return response()->json([
                'success' => false,
                'message' => "Data gagal dihapus"
            ],400);    
        }
    }
}

# FLAPPY BIRD Game Project

Game sederhana berbasis Unity yang terinspirasi dari Flappy Bird. Pemain harus menghindari pipa/obstacle yang bergerak.

## Tentang Game
- Engine: Unity
- Genre: Casual/Arcade
- Platform: PC/Mobile

## Cara Setup Project

1. Clone repository ini
2. Buka Unity Hub
3. Add project dengan memilih folder hasil clone
4. Buka project menggunakan Unity Editor versi yang sesuai

## PENTING: Inisialisasi Project

Sebelum mulai development, developer **WAJIB** mengetikkan:
```
initialize this project
```
pada Cline/Roo untuk menginisialisasi project dan mendapatkan context yang diperlukan.

## Struktur Project
```
Assets/
├── Prefab/         # Prefab komponen game
├── Scenes/         # Scene Unity
├── Scripts/        # Script C#
└── UI Toolkit/     # Asset UI
```

### Komponen Utama
- PlayerController.cs: Mengatur kontrol dan physics player
- GameManager.cs: Mengatur state dan logic game
- PipeSpawner.cs: Sistem spawning obstacle
- Pipe.cs: Behavior obstacle

## Kontribusi
1. Fork repository
2. Buat branch untuk fitur baru
3. Commit changes
4. Buat pull request

## Lisensi
Project ini menggunakan lisensi [MIT License](LICENSE).

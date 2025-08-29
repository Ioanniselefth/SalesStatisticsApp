# 📘 Sales Statistics Application – README

## 📦 Requirements
- [.NET SDK](https://dotnet.microsoft.com/download) installed (version 6.0 or higher).  
  Verify installation:
  ```bash
  dotnet --version
  ```

## ▶️ How to Build & Run
1. **Clone or copy the project** to your computer.  
   Example folder:  
   ```
   D:\Workspace\SalesStatisticsApp
   ```

2. **Open a terminal / PowerShell** in the project folder.  

3. **Build the project**:
   ```bash
   dotnet build
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

---

## 📂 Input File Format
- The sales data must be in a text file (e.g., `sales.txt`).  
- Each line contains:
  ```
  <date><delimiter><amount>
  ```
- Example:
  ```
  31/03/2020##245.39
  01/04/2020##150.00
  15/05/2020##300.50
  20/01/2021##500.00
  ```
- Default delimiter = `##`  
- Default date format = `dd/MM/yyyy`  

---

## 🖥️ Using the Program
When you run `dotnet run`, you will see:

```
===== Sales Statistics Application =====
Enter file path:
Enter delimiter (default ##):
Enter date format (default dd/MM/yyyy):
Loading data...
```

1. **Enter file path**  
   Example:  
   ```
   D:\Workspace\SalesStatisticsApp\sales.txt
   ```

2. **Enter delimiter** (press Enter for default `##`).  

3. **Enter date format** (press Enter for default `dd/MM/yyyy`).  

---

## 📊 Menu Options
You will then see a menu:

```
===== MENU =====
1. Average earnings for a range of years
2. Standard deviation within a specific year
3. Standard deviation for a range of years
0. Exit
```

- **Option 1** → Enter start year and end year, program prints the average sales.  
- **Option 2** → Enter a specific year, program prints the standard deviation of that year’s sales.  
- **Option 3** → Enter start year and end year, program prints the standard deviation across that range.  
- **Option 0** → Exit program.  

---

## ✅ Example Run
```
===== Sales Statistics Application =====
Enter file path: D:\Workspace\SalesStatisticsApp\sales.txt
Enter delimiter (default ##):
Enter date format (default dd/MM/yyyy):
Loading data...

===== MENU =====
1. Average earnings for a range of years
2. Standard deviation within a specific year
3. Standard deviation for a range of years
0. Exit
Enter your choice: 1
Enter start year: 2020
Enter end year: 2021
Average earnings (2020-2021): 374.57
```

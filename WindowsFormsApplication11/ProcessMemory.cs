using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication11
{
    //http://peryaudo.hatenablog.com/entry/20100516/1273998518
    class ProcessMemory
    {
    }
    /*
int SearchProcesses(HWND hWnd){
        HANDLE hSnap;
        PROCESSENTRY32 pe;
        DWORD dwProcessId = 0;
        static DWORD dwProcessIdLast;
        BOOL bResult;

        if((hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0)) == INVALID_HANDLE_VALUE){
                MessageBox(NULL, "CreateToolhelp32Snapshot() failed", PROGRAM_TITLE, MB_OK | MB_ICONERROR);
                ExitProcess(-1);
                return 0;
        }

        pe.dwSize = sizeof(pe);

        bResult = Process32First(hSnap, &pe);

        while(bResult){
                if(!lstrcmpi(pe.szExeFile, "Typing.exe")){
                        dwProcessId = pe.th32ProcessID;
                        break;
                }
                bResult = Process32Next(hSnap, &pe);
        }

        CloseHandle(hSnap);

        if(dwProcessId != 0 && dwProcessId != dwProcessIdLast){
                dwProcessIdLast = dwProcessId;
                PatchProcess(dwProcessId);
        }



        return 0;
}


            HANDLE hProcess;
        if((hProcess = OpenProcess(PROCESS_ALL_ACCESS, TRUE, dwProcessId)) == NULL){
                MessageBox(NULL, "OpenProcess failed", PROGRAM_TITLE, MB_OK | MB_ICONERROR);
                ExitProcess(-1);
                return -1;
        }



            unsigned char current[6];
        unsigned char firstJNZ[6] = { 0x0F, 0x85, 0xE3, 0x00, 0x00, 0x00 };

        // first JNZ
        if(!ReadProcessMemory(hProcess, (LPCVOID)0x0043074D, (LPVOID)current, 6, NULL)){
                MessageBox(NULL, "ReadProcessMemory failed", PROGRAM_TITLE, MB_OK | MB_ICONERROR);
                ExitProcess(-1);
                return -1;
        }

        if(!CompareArray(6, firstJNZ, current)){
                MessageBox(NULL, "Typing.exe has changed since the patcher was written.", PROGRAM_TITLE, MB_OK | MB_ICONERROR);
                ExitProcess(-1);
                return -1;
        }

    int CompareArray(int len, unsigned char *a, unsigned char *b){
        int i = 0;
        for(i = 0; i < len; i++){
                if(*(a + i) != *(b + i)) return 0;
        }
        return 1;







            unsigned char patched[6] = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

        if(!WriteProcessMemory(hProcess, (LPVOID)0x0043074D, (LPVOID)patched, 6, NULL)){
                MessageBox(NULL, "WriteProcessMemory failed", PROGRAM_TITLE, MB_OK | MB_ICONERROR);
                ExitProcess(-1);
                return -1;
        }
        if(!WriteProcessMemory(hProcess, (LPVOID)0x0043075A, (LPVOID)patched, 6, NULL)){
                MessageBox(NULL, "WriteProcessMemory failed", PROGRAM_TITLE, MB_OK | MB_ICONERROR);
                ExitProcess(-1);
                return -1;
        }
}

*/
}

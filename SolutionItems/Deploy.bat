REM @echo off
REM %1 should be the $(ProjectDir) macro in msbuild.
REM %2 should be the $(OutDir) macro in msbuild.

SET _defs=Defs
IF EXIST "%~dp1%_defs%" (
    xcopy /i /e /d /y "%~dp1%_defs%" "%~dp2..\%_defs%"
)

SET _languages=Languages
IF EXIST "%~dp1%_languages%" (
    xcopy /i /e /d /y "%~dp1%_languages%" "%~dp2..\%_languages%"
)

SET _patches=Patches
IF EXIST "%~dp1%_patches%" (
    xcopy /i /e /d /y "%~dp1%_patches%" "%~dp2..\%_patches%"
)

SET _textures=Textures
IF EXIST "%~dp1%_textures%" (
    xcopy /i /e /d /y "%~dp1%_textures%" "%~dp2..\%_textures%"
)

SET _assemblies=Assemblies
IF NOT "%3"=="Debug" (
    IF EXIST "%~dp2..\%_assemblies%\*.pdb" (
        DEL /q "%~dp2..\%_assemblies%\*.pdb"
    )
)
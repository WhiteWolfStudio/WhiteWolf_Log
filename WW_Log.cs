using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace WhiteWolf {

    public class WW_Log : MonoBehaviour {

        public bool editor;
        public string path;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        RuntimePlatform platform;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        private void Awake(){

            GetPlatform();
            GetPath();

            CheckFile();

            newLog();

        }

        private void Start(){

            GetPlatform();
            GetPath();

            CheckFile();

            newLog();

        }

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void GetPlatform() => platform = Application.platform;

        void GetPath(){

            if ( platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.LinuxEditor ){
                editor = true;
                path = "Assets/file.log";
            }
            else { path = $"{Application.persistentDataPath}/file.log"; }

        }

        void CheckFile(){

            if ( !File.Exists( path ) ){

                StreamWriter w = File.CreateText( path );
                w.Close();

            }

        }

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        public bool Editor(){ return editor; }
        public string Path(){ return path; }

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        public void log( string data ){

            CheckFile();

            StreamWriter w = File.AppendText(path);
            w.Write($"{System.DateTime.Now} | {Time.time }: {data}\n");
            w.Close();

        }

        public void newLog(){

            CheckFile();

            StreamReader sr = new StreamReader( path );
            string file = sr.ReadToEnd();
            sr.Close();

            StreamWriter w = File.AppendText(path);

            if ( file == "" || file == " " || file == null ){ w.Write( $"{System.DateTime.Now}\n" ); }
            else { w.Write( $"\n{System.DateTime.Now}\n" ); }

            w.Close();

        }

    }

}
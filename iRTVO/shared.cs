﻿/*
 * shared.cs
 * 
 * SharedData class:
 * 
 * Holds the data structures which are shared between API and overlay.
 * 
 * API uses mutexes while writing to the DriverInfo, LapInfo, SessionInfo and TrackInfo structures.
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// additional
using System.Threading;
using iRSDKSharp;
using System.ComponentModel;

namespace iRTVO
{

    class SharedData
    {
        // Mutexes
        public static Mutex writeMutex = new Mutex(false);
        public static Mutex readMutex = new Mutex(false);

        // API state
        public static Boolean runApi = true;
        public static Boolean runOverlay = false;
        public static Boolean apiConnected = false;
        public static Boolean isLive = true;

        // Overlay performance timers
        public static Stack<float> overlayFPSstack = new Stack<float>();
        public static Stack<float> overlayEffectiveFPSstack = new Stack<float>();
        public static int cacheHit = 0;
        public static int cacheMiss = 0;
        public static int cacheFrameCount = 0;

        // Theme
        public static Theme theme;
        public static Boolean refreshButtons = false;
        public static Boolean refreshTheme = false;
        public static int replayRewind = 0;
        public static Boolean inReplay = false;
        public static int overlaySession = 0;
        
        public static Dictionary<Theme.sessionType, int> sessionTypes = new Dictionary<Theme.sessionType, int>()
        {
            {Theme.sessionType.none, 0},
            {Theme.sessionType.practice, 0},
            {Theme.sessionType.qualify, 0},
            {Theme.sessionType.race, 0}
        };

        public static Boolean[] lastPage;
        public static String[][] themeDriverCache = new string[64][];
        public static String[] themeSessionStateCache = new string[0];
        public static Double themeCacheSessionTime = 0;
        public static Stack triggers = new Stack();
        public static Double currentSessionTime = 0;

        // allow retirement
        public static Boolean allowRetire = false;

        // csv
        public static Dictionary<int, string[]> externalData = new Dictionary<int, string[]>();

        // web timing
        public static webTiming web;
        public static Int64 webBytes = 0;
        public static String webError;

        // Data
        public static List<DriverInfo> Drivers = new List<DriverInfo>();
        public static Sessions Sessions = new Sessions();
        public static TrackInfo Track = new TrackInfo();
        public static CameraInfo Camera = new CameraInfo();
        public static Events Events = new Events();
        public static Bookmarks Bookmarks = new Bookmarks();
        public static List<Single> Sectors = new List<Single>();
        public static List<Single> SelectedSectors = new List<Single>();
        public static Int32[] Classes = new Int32[3] {-1, -1, -1};

        // Update stuff
        public static Boolean updateControls = false;
        public static Boolean showSimUi = true;

    }
}

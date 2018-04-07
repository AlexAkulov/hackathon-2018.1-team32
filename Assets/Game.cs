using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour
{

	public GameObject Web;
	public GameObject Chest;
	
	
	private const int NumberOfRooms = 5;
	private const int NumberOfWeb = 10;
	private const int NumberOfChests = 5;
	
	
	private const int Height = 31;
	private const int Width = 60;

	private const int Left = (-2 * Width);
	private const int Top = (-4 * Height);
	
	private struct Room
	{
		public GameObject web;
		public GameObject chast;
	}
	
	private Room[,] Level = new Room[NumberOfRooms,NumberOfRooms];
	

	
	// Use this for initialization
	void Start () {
		print("Start Game");
		BuildLevel();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void generateWeb()
	{
		for (var i = 0; i < NumberOfWeb; i++)
		{
			var x = UnityEngine.Random.RandomRange(0, NumberOfRooms);
			var y = UnityEngine.Random.RandomRange(0, NumberOfRooms);
			
			var w = Instantiate(Web);
		
			w.transform.position = new Vector3(x*Width + Left- 22, y*Height + Top + 8, 0);
			Level[x,y].web = w;
		}
	}

	private void generateChest()
	{
		for (var i = 0; i < NumberOfWeb; i++)
		{
			var x = UnityEngine.Random.RandomRange(0, NumberOfRooms);
			var y = UnityEngine.Random.RandomRange(0, NumberOfRooms);
			
			var w = Instantiate(Chest);
		
			w.transform.position = new Vector3(x*Width + Left, y*Height + Top, 0);
			Level[x,y].web = w;

			print(string.Format("create web on x: {0} y: {1}", x, y));
		}
	}

	private void BuildLevel()
	{
		generateWeb();
		generateChest();
	}
}

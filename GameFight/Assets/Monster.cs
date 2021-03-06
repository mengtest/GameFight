﻿using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	private Vector2 hpsize = new Vector2(1f, 0.2f);
	private Transform mytransform;
	public Material hp_bar;

	void Awake(){
		mytransform = transform;
	
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public Transform SetHpbar()
	{
//		for (int i = 0; i < 15; i++)
//		{
//			if (this.c_hpbar[i].position.y > 2f)
//			{
//				this.selecthpbar = this.c_hpbar[i];
//				break;
//			}
//		}
//		return this.selecthpbar;
		Transform bar = CreatHpbar (this.hpsize, false, true);
		bar.position = Vector3.one * 4f;
		return bar;
	}



	public Transform CreatHpbar(Vector2 _size, bool _turretmode, bool _ally)
	{
		GameObject gameObject = new GameObject("hp_bar");
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		Mesh mesh = new Mesh();
		gameObject.AddComponent<MeshRenderer>();
		mesh.vertices = new Vector3[]
		{
			new Vector3(-_size.x,0f , _size.y) * 0.5f,
			new Vector3(_size.x, 0f, _size.y) * 0.5f,
			new Vector3(-_size.x,-0.02f,  -_size.y) * 0.5f,
			new Vector3(_size.x, -0.02f, -_size.y) * 0.5f
		};
		float num = 0f;
		if (_ally)
		{
			num = 0.75f;
		}
		mesh.uv = new Vector2[]
		{
			new Vector2(0f, 0.25f + num),
			new Vector2(0.5f, 0.25f + num),
			new Vector2(0f, num),
			new Vector2(0.5f, num)
		};
		Renderer renderer = gameObject.renderer;
		renderer.receiveShadows = false;
		renderer.castShadows = false;
		renderer.sharedMaterial = this.hp_bar;
		mesh.triangles = new int[]
		{
			0,
			1,
			2,
			2,
			1,
			3
		};
		mesh.RecalculateNormals();
		meshFilter.mesh = mesh;
		gameObject.transform.parent = this.mytransform;
		gameObject.AddComponent ("Hp_bar");
		return gameObject.transform;
	}
}

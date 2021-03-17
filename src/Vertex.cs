using System;

public class Vertex
{
	private person_name: string;
	private edges: string[];
	
	public Vertex(name: string) {
		this.person_name = name;
		this.edges = [];
	}

	public get name(): string {
        return this.person_name;
    }
	public set name(name: string) {
		this.person_name = name;
	}
	public get edges(): string[] {
		return this.edges;
	}
	public set edges(links: string[]) {
		this.edges = links;
	}


}

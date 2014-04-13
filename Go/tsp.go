package main

import (
	"fmt"
	"math"
	"bytes"
	"os"
	"time"
)

type Point struct {
	X, Y int
}

var points []Point
var minLength float64
var shortestPath string
var sb bytes.Buffer

func main() {
	
	initialize()

	begin := time.Now()

	calculateShortestPath()

	diff := time.Since(begin)

    fmt.Printf("length: %v\n", minLength)
    fmt.Printf("path: %v\n", shortestPath)
    fmt.Printf("time: %s\n", diff)

    writeLog()
}

func initialize() {
	
	points = []Point {
		Point{327, 95},
		Point{389, 92},
		Point{581, 152},
		Point{511, 229},
		Point{708, 242},
		Point{280, 284},
		Point{397, 311},
		Point{609, 360},
		Point{448, 411},
		Point{259, 437},
		//Point{579, 495},
		//Point{427, 540},
	}
}

func calculateShortestPath() {
	
	minLength = math.Inf(0)
	sb.Reset()

    indices := make([]int, len(points))

    for i := 0; i < len(indices); i++ {
        indices[i] = i
    }

    recSwap(indices, 0, len(indices) - 1)
}

func recSwap(list []int, k int, m int) {

	//sb.WriteString(fmt.Sprintf("k = %v, m = %v, list = %v\n", k, m, pathToString(list)))

	if k == m {
        calculatePath(list);
    } else {

        for i := k; i <= m; i++ {

            swap(&list[k], &list[i])

            recSwap(list, k + 1, m);

            swap(&list[k], &list[i])
        }
    }
}

func calculatePath(indices []int) {
	
	path := 0.0;
    prev := -1;

    for _, current := range indices {
        
        if prev > -1 {
            path += pointDistance(points[prev], points[current])
        }

        prev = current;
    }

    last := points[indices[len(indices)-1]]
    first := points[indices[0]]

    path += pointDistance(last, first)

    if path < minLength {
        minLength = path
        shortestPath = pathToString(indices)
    }
}

func pointDistance(p Point, q Point) float64 {

	return distance(p.X, p.Y, q.X, q.Y)
}

func distance(px int, py int, qx int, qy int) float64 {

	return math.Sqrt(math.Pow(float64(qx) - float64(px), 2) + math.Pow(float64(qy) - float64(py), 2))
}

func pathToString(indices []int) string {
	
	shortestPath := ""

	for _, current := range indices {

		shortestPath += fmt.Sprintf("%v-", current)
	}

	return shortestPath[:len(shortestPath) - 1]
}

func swap(a *int, b *int) {

    if *a != *b {

	    tmp := *a
	    *a = *b
	    *b = tmp
	}
}

func writeLog() {

	if sb.Len() > 0 {

		f, err := os.Create("c:\\temp\\tspbf.go.log")

	    if err != nil {
	    	panic(err)
	    }

	    defer f.Close()

	    _, err = f.Write(sb.Bytes())

	    if err != nil {
	    	panic(err)
	    }	
	}
}
#include <stdio.h>
#include <math.h>
#include <time.h>

typedef struct
{
    int x;
    int y;
} Point;

#define COUNT 10

double minLength;
char shortestPath[COUNT * 2];

Point points[COUNT] = {
    {327, 95},
    {389, 92},
    {581, 152},
    {511, 229},
    {708, 242},
    {280, 284},
    {397, 311},
    {609, 360},
    {448, 411},
    {259, 437},
    //{579, 495},
    //{427, 540}
};

void swap(int * a, int * b)
{
    if(*a != *b)
    {
        int tmp = *a;
        *a = *b;
        *b = tmp;
    }
}

void setPathToString(int * indices)
{
    for(int i = 0; i < COUNT; i++)
    {
        shortestPath[i * 2] = '0' + indices[i];
        shortestPath[i * 2 + 1] = '-';
    }

    shortestPath[(COUNT - 1) * 2 + 1] = '\0';
}

double distance(int px, int py, int qx, int qy)
{
    return sqrt(pow(qx - px, 2) + pow(qy - py, 2));
}

double pointDistance(Point * p, Point * q)
{
    return distance(p->x, p->y, q->x, q->y);
}

void calculatePath(int * indices)
{
    double path = 0.0;
    int prev = -1;

    for(int i = 0; i < COUNT; i++) {
        int current = indices[i];

        if(prev > -1)
        {
            path += pointDistance(&points[prev], &points[current]);
        }

        prev = current;
    }

    Point last = points[indices[COUNT-1]];
    Point first = points[indices[0]];

    path += pointDistance(&last, &first);

    if(path < minLength)
    {
        minLength = path;
        setPathToString(indices);
    }
}

void recSwap(int * list, int k, int m)
{
    if(k == m)
    {
        calculatePath(list);
    }
    else
    {
        for(int i = k; i <= m; i++)
        {
            swap(&list[k], &list[i]);

            recSwap(list, k + 1, m);

            swap(&list[k], &list[i]);
        }
    }
}

void calculateShortestPath()
{
    minLength = 99999999999.9;

    int indices[COUNT];

    for(int i = 0; i < COUNT; i++)
    {
        indices[i] = i;
    }

    recSwap(indices, 0, COUNT - 1);
}

int main()
{
    clock_t start = clock();

    calculateShortestPath();

    double diff = clock() - start;

    printf("length: %f\n", minLength);
    printf("path: %s\n", shortestPath);
    printf("time (sec): %f\n", diff / CLOCKS_PER_SEC);

    return 0;
}
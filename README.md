### GLOSA.NET ###
.Net implementation of the [Glosa Geomety Library](https://github.com/elQuixote/glosa) 

### GLOSA GEOMETRY LIBRARY ###
Glosa is a cross platform, high performance geometry library written in Nim by Robert Wells & Luis Quinones at Mode Lab. The main goal behind this library was centered around improving our development turnaround time by removing the need to rewrite many of our algorithms as well as optimizing current algorithms which interface with our daily design and development tools. This process would allow us to create a single and unifying language for connecting disparate platforms.

--------------------------------------------------------------

### .NET GEOMETRY WRAPPER ###
Currently we have created the wrapper around the first building blocks of the core geometry library.

### Interfaces ###
* IClear
* IClosest
* ICompare
* ICopy
* IDimension
* IEquals
* IHash
* ILength
* IMatrix
* IMatrices
* IShape2
* IString
* ITransform
* IVector
* IVectors
* IVertices

### Helpers ###
* Json .Net
* GlosaObject

## Geometry ##
### Matrix ###
* 3x3 & 4x4 Matrices [for calculating general spatial transforms]

### Path ###
* Polylines [for representing linear curve data]
* NURBS Curves [for representing non-linear curve data]

### Polygon ###
* Polygons [for representing planar shapes with linear sides]

### Quaternions ###
* Quaternions [for calculating rotational transforms]

### Shape ###
* Circles [for representing circles]
* LineSegments [for linear elements]

### Vectors ###
* 1-4 Dimensional Vectors [for representing spatial data]

--------------------------------------------------------------

### .NET INTERFACE ###
Some notes:
* Need a custom marshaller for dynamically allocated types
* Currently using JSON to serialize and deserialize dynamically allocated types (terrible solution, need custom marshall)
* Going between Nim, C, and FFIs (especially in C#) needs some work 

--------------------------------------------------------------

### PERFORMANCE ###
See performance tests on the [Glosa Geomety Library](https://github.com/elQuixote/glosa) page

